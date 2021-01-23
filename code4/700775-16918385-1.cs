    public IList<SelectListItem> FillCourseList(int id)
            {
                List<master_tasks> lst = new List<master_tasks>();
                lst = _taskInterface.getMasterTasks();
                IList<SelectListItem> items = new List<SelectListItem>();
    
                items.Add(new SelectListItem
                    {
                        Text = "Select Task",
                        Value = "0"
                    });
                for (int i = 0; i < lst.Count; i++)
                {
                    items.Add(new SelectListItem
                    {
                        Text = lst[i].code + " - " + lst[i].name,
                        Value = lst[i].id.ToString()
                    });
                }
                return items;
            }
