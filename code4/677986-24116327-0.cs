    private void SearchData()
    { Model1Container model = new Model1Container();
    try
    {
    var query = model.Scholars.AsQueryable();
    if(!string.IsNullOrEmpty(this.txtSearch.Text))
     {
    //  query = query.Where(x=>x.ScholarName.StartsWith(txtSearch.Text));
     query = (from Schl in model.Scholars
    where Schl.ScholarName.StartsWith(txtSearch.Text) ||
     Schl.PhoneRes.StartsWith(txtSearch.Text) || 
     Schl.PhoneOff.StartsWith(txtSearch.Text) ||
    Schl.Mobile.StartsWith(txtSearch.Text) ||
    Schl.Email.StartsWith(txtSearch.Text)
    orderby Schl.ScholarName
    select Schl);
    }
    this.dgvScholarList.DataSource = query.ToList();
     }
    catch (Exception ex)
    {
    MessageBox.Show(ex.Message);
     }
    }       
