    PersonProxy p = new PersonProxy();
    p.Guid = Guid.NewGuid();
    p.First = txtFirst.Text;
    p.Last = txtLast.Text;
    p.Email = txtEmail.Text;
    p.Phone = txtPhone.Text;
    p.Site = txtSite.Text;
    var list = new List<Person>();
    list.Add(p);
