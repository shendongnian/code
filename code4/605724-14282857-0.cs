            MasterType value = new MasterType();
            foreach (var t in typeof(MasterType.TypeA).GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.FlattenHierarchy))
            {
                var fieldValue = t.GetValue(value.typeA);
                foreach (var field in t.FieldType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public))
                {
                    Console.WriteLine(field.Name + " | " + field.GetValue(fieldValue));
                }
            }
