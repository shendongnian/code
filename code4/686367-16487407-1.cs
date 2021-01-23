    class FormReferenceHolder
    {
        private static Form1 form1;
        public static Form1 Form1
        {
            get
            {
                if (form1 == null) form1 = new Form1(); 
                return form1 ;
            }
        }
    }
...
    static void Main()
    {
        Application.Run(FormReferenceHolder.Form1 );
    }
