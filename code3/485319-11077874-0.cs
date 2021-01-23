    public class SurveyEmailListModelsModelBinder: DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var csv = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            var file = ((csv.RawValue as HttpPostedFileBase[]) ?? Enumerable.Empty<HttpPostedFileBase>()).FirstOrDefault();
            if (file == null || file.ContentLength < 1)
            {
                bindingContext.ModelState.AddModelError(
                    "", 
                    "Please select a valid CSV file"
                );
                return null;
            }
            using (var reader = new StreamReader(file.InputStream))
            using (var csvReader = new CsvReader(reader))
            {
                return csvReader.GetRecords<SurveyEmailListModels>().ToArray();
            }
        }
    }
