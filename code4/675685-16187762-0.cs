       private void btnFindandReplace_Click(object sender, EventArgs e)
        {
            string text = System.IO.File.ReadAllText("dataemployee.txt");
            text = text.Replace(txtEmployeeIDFind.Text, txtEmployeeIDReplace.Text).Replace(txtContactFind.Text, txtContactReplace.Text);
            System.IO.File.WriteAllText("dataemployee.txt", text);
        }
