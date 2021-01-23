    public void BtnClickHandler(Office.IRibbonControl btn)
        {
            var ex = btn?.Context?.Parent as Outlook.Explorer;
            if (ex == null) return;
            foreach (var sel in ex.Selection)
            {
                var mailItem = sel as Outlook.MailItem;
                if (mailItem != null) DoSomethingWith(mailItem);
            }
        }
