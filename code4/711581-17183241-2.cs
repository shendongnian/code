        class Form2: Form
        {
             private Form1 form1Object;
             public Form2(Form1 obj)
             {
                  form1Object = obj;
             }
             private void SomeMethodInForm2()
             {
                  //Here you can access the variable in form1 like
                  form1Object.PropertyNameYouWantToAccess;
             }
         }
