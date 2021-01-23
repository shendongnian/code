    var user = from u in db.tbl_User select new {u.UserName,u.Password};
    if(user.Count() != 1)
        return;
    if(txtname == user.UserName && txtpass == pass.Password)
    {
            Form2 frm = new Form2();
            Visible = false;
            frm.Show();
            }
            else
            {
               MessageBox.Show("Error","UserName or Password is wrong" ,MessageBoxButtons.OK);
    }
