    public class myWalletAgent : WalletAgent
    {
        protected override void OnRefreshData(RefreshDataEventArgs args)
        {
            foreach (WalletItem item in args.Items)
            {
                item.SetUserAttentionRequiredNotification(true);
            }
    
            base.OnRefreshData(args);
            NotifyComplete();
        }
    }
