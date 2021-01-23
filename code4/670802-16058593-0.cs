        public void Discover(ShapeTableBuilder builder)
        {
            builder.Describe("MyModel").OnDisplaying(
                displaying =>
                    {
                        var elementObject = displaying.Shape;
                        var elementId = elementObject.Id;
                        elementObject.Metadata.Alternates.Add("MyModel__" + EncodeAlternateElement(elementId));
                    });
        }
        private string EncodeAlternateElement(string alternateElement)
        {
            return alternateElement.Replace("-", "__").Replace(".", "_");
        }
