            var dx = new DataModelDataContext();
            List<Dog> dogList = dx.Dogs.AsEnumerable().ToList();
            string PropetyToCheck = "MyProperty";
            PropertyInfo property = typeof(Dog).GetProperty(PropetyToCheck);
            try
            {
                return
                    dogList.SkipWhile(x => property.GetValue(x, null) != dogId).Skip(1).FirstOrDefault().Id.ToString(
                        CultureInfo.InvariantCulture);
            }
