    public static class FieldOperator
    {
        public static void Operate(Field[] fields)
        {
            foreach (var field in fields)
            {
                field.Label = field.GetType().ToString();
                switch (field)
                {
                    case Field<Document> docField:
                        docField.Value.Content = "Foo Bar";
                        break;
                    case Field<int> intField:
                        intField.Value = 600842;
                        break;
                    default:
                        field.Label = "Oops";
                        break;
                }
            }
        }
    }
