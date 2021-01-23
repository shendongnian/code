    public class DetailFrm
    {
        private readonly Func<ListFrm> _listFrmInstance;
        public DetailFrm(Func<ListFrm> listFrmInstance)
        {
            _listFrmInstance = listFrmInstance;
        }
        private SelectButton OnClick(object sender, EventArgs e)
        {
            using(var listFrm = _listFrmInstance())
            {
                listFrm.ShowDialog();
    
                // Do detail data filling here
            }
        }
    }
