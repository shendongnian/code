    [In VB.Net]
    Imports CrystalDecisions.Windows.Forms
    Private Sub CrystalView_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim crv As New CrystalReportViewer
            With crv
                .Dock = DockStyle.Fill
            End With
            Me.Controls.Add(crv)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    [In C#]
    using CrystalDecisions.Windows.Forms;
    public class CrystalView
    {
    	private void CrystalView_Load(System.Object sender, System.EventArgs e)
    	{
    		try {
    			CrystalReportViewer crv = new CrystalReportViewer();
    			 crv.Dock = DockStyle.Fill;
    			crv.EnableDrillDown = false;
    			this.Controls.Add(crv);
    		} catch (Exception ex) {
    			MessageBox.Show(ex.Message,"Hello");
    		}
    	}
    	public CrystalView()
    	{
    		Load += CrystalView_Load;
    	}
    }
