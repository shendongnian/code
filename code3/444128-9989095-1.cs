    ...
    ucBeheer ucBeheer = new ucBeheer();
    ucBeheer.StatusChanged += HandleStatusChanged;
    splitContainer1.Panel2.Controls.Add(ucBeheer);
    ...
    partial class MyForm : Form
    {
        void HandleStatusChanged( object sender, StatusChangedEventArgs args )
        {
            lblStatus.Text = args.Text;
        }
    }
