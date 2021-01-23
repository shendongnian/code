    public interface IMyInterface
    {
        object TransactionData
        {
           get;
           set;
        }
    }
    Control effortControl = Page.LoadControl(path);
    HtmlContent.Controls.Add(effortControl);
    IMyInterface obj = (IMyInterface)effortControl;
    obj.TransactionData = transaction;
