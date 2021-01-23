    class FormList{
     public List<System.Windows.Forms.Form> MyForms=new List<System.Windows.Forms.Form>();
     public void UpdateSomething(Color cols){
        foreach(Form ThisForm in MyForms){
            ThisForm.Color=cols
        }
     }
     //etc...
    }
