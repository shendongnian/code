    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Windows.Forms;
    class MyApplicationContext : ApplicationContext
    {
        public List<Form> Forms = new List<Form>() {
            new Form1()
        };
        private List<Form> FormCollectionToList(FormCollection fc)
        {
            List<Form> ff = new List<Form>();
            foreach (Form f in fc)
            {
                ff.Add(f);
            }
            return ff;
        }
        private void onFormClosed(object sender, EventArgs e)
        {
            Forms = FormCollectionToList(Application.OpenForms);
            if (Forms.Count == 0)
            {
                ExitThread();
            }
            foreach (var form in Forms)
            {
                form.FormClosed -= onFormClosed;
                form.FormClosed += onFormClosed;
            }
        }
        public MyApplicationContext()
        {
            if (Forms.Count == 0)
            {
                Process.GetCurrentProcess().Kill();
            }
            foreach (var form in Forms)
            {
                form.FormClosed += onFormClosed;
                form.Show();
            }
        }
    }
