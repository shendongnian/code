    public List<ElementModelForCourseIndex> GetElementModelsForCourseIndex(int elementId, int userId, int depthLevel = 2)
        {
            List<ElementModelForCourseIndex> courses;
            using (var db = DataContextManager.AleStoredProcsContext)
            {
                courses =  db.GetElementModelsForCourseIndex<ElementModelForCourseIndex>(elementId, userId, r => new ElementModelForCourseIndex{
                        Id = ElementsModelsForCourseIndexMap.Id(r),
                        Identity = ElementsModelsForCourseIndexMap.Identity(r)
                    }).OrderBy(n=>n.Identity).ToList();
            }
            for each(ElementModelForCourseIndex course in courses)
            {
                // here you are filling the Children. 
                //You need to check if the parameters are the correct ones. 
                // Since you haven't shown the actual model class, I'm only guessing the parameters
                course.Children = GetElementChildrenModelsForCourseIndex(elementId, userId, depthLevel);
            }
            return courses;
        }
