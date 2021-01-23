    public partial class UcSelecionarLocal : UserControl
    {
    	protected void Page_Load(object sender, EventArgs e)
    	{
    	}
    	public void PreencherLocais()
    	{
    		ddlLocais.Items.Clear();
    		ddlLocais.Items.Add(new ListItem("Selecione", "0"));
    		ControleLocal controle = new ControleLocal();
    		DataTable tab = controle.ListarLocais();
    		foreach (DataRow row in tab.Rows)
    		{
    			ddlLocais.Items.Add(new ListItem(row["Descricao"].ToString(), row["ID"].ToString()));
    		}
    	}
    }
