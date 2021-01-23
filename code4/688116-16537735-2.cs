    interface IDataTarget
    {
      void Update(int id, string name); // you should reflect here all of your data
    }
    
    class Form1
      : Form, IDataTarget
    {
      public void Update(int id, string name)
      {
         // add new record here
      }
    
      private void AddButton_Click(...)
      {
        using(var form2 = new Form2(this))
        {
           form.ShowDialog(this);
        }
      }
    }
    
    class Form2
      : Form
    {
      private readobly IDataTarget dataTarget;
    
      public Form2(IDatatarget dataTarget)
      {
        this.dataTarget = dataTarget;
      }
    
      private OK_Click(...)
      {
         dataTarget.Update(textBox1.Text, textBox2.Text);
         ClearTheControls();
      }
    }
