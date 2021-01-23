        public class GenericsOfString : Generics<String>
        {
            public GenericsOfString(String text, Boolean isErrorMessage)
            {
                if (isErrorMessage)
                {
                    this.ErrorMessage = text;
                }
                else
                {
                    this.Member = text;
                }
            }
        }
