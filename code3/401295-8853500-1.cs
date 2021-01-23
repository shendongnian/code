     public void GetPoints()
            {
                string inputFields = HttpContext.Current.Request["inputFields"];
                var test = new[] { new { ID = 0, FieldType = string.Empty, Description = string.Empty } };
                var fields = JsonConvert.DeserializeAnonymousType(items, test);
            }
