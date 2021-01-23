    public class MyCommands {
        [CommandMethod("NS", "TEST", "TEST", CommandFlags.Modal)]
        public void TestCommand() // This method can have any name
        {
            Form fromAutoCADAPI = new TestForm();
            Form independent1 = new TestForm();
            Form independent2 = new TestForm();
            //Using AutoCAD application
            Autodesk.AutoCAD.ApplicationServices.Application.ShowModelessDialog(fromAutoCADAPI);
            independent1.Show();
            independent2.Show();
            //Using Windows Forms Application
            var count = System.Windows.Forms.Application.OpenForms.Count; //should be 3
            Autodesk.AutoCAD.ApplicationServices.Application.ShowAlertDialog(count.ToString());
        }
    }
