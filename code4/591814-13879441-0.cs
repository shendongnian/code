    public class MyObject {
      public string text;
      public string value;
    
      public MyObject(string text, string value) {
        this.text = text;
        this.value = value;
      }
    }
    
    public class MyClass {
      List<MyObject> objects;
      public void OnLoad(object sender, EventArgs e) {
        objects = new List<MyObjcet>();
        //add objects
        lstbx.DataSource = objects;
        lstbx.DataTextField = "text";
        lstbx.DataValueField = "value";
        lstbx.DataBind();
      }
    }
