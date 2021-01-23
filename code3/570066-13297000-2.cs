    private Form1 _FindForm()
    {
       //assuming you can use Linq
       return Application.OpenForms.OfType<Form1>().Single();
    }
    public void displaySomething()
    {
       var form = _FindForm();
       form.displaySomething();
    }
---
    public class Form1
    {
      public void displaySomething()
      {
        //add an item to the list box
        listBox1.Items.Add("foo");
        //and change the text somewhere
        textBox1.Text += "bar";
      }
    }
