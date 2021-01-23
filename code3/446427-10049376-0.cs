    public interface IMyInterface
    {
        object TransactionData
        {
           get;
           set;
        }
    }
    var path = string.Format("~/NAVLSeriesControls/{0}Effort{1}.ascx", renewalDef, effortNumber);
    IMyInterface effortControl = (IMyInterface)Page.LoadControl(path);
    effortControl.TransactionData = transaction;
    
    HtmlContent.Controls.Add(effortControl);
