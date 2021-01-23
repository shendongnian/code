    public partial class FrmPartialMain : Form
    {   
        RsiOPCAuto.OPCServer oOpcServer;
        RsiOPCAuto.OPCGroup oOpcGroup;
        int ClHandle; //this is set to 1 in another part of the code.
        int SvHandle;
        int OpcDsCashe = 1;
        int OpcDsDevice = 2;
        private void cmdSyncRead_Click(object sender, EventArgs e)                                                                                  //Sync Read
        {
            int lNumItems = oOpcGroup.OPCItems.Count;
            int[] arH = new int[1 + lNumItems];
            Array arValues = new object[1 + lNumItems]; //<-- This needed to be an object.
            Array arHandles;
            Array arErrors;
            object Qualities;
            object Timestamps;
            arH[ClHandle] = oOpcGroup.OPCItems.Item(ClHandle).ServerHandle;
            arHandles = (Array)arH;
            oOpcGroup.SyncRead((short)OpcDsDevice, lNumItems, ref arHandles, out arValues, out arErrors, out Qualities, out Timestamps);
            txtSubValue.Text = Convert.ToString(arValues.GetValue(1));
        }
    }
