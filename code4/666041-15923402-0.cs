Organizations table = new DimaeSQLDS.Organizations();
using(OrganizationsTableAdapter orgAdapter = new DimaeApplication.DimaeSQLDSTableAdapters.OrganizationsTableAdapter())
{
    orgAdapter.Fill(table);
    DimaeSQLDS.OrganizationsRow organizationsRow = table.NewOrganizationsRow();
    organizationsRow.Address = tbINN.Text;            
    organizationsRow.OrgName = tbOrgName.Text;           
    dsAddToDima.Organizations.Rows.Add(organizationsRow); //adds row to DataSet
    orgAdapter.Update(dsAddToDima.Organizations);
}
