        public override void DeactivateItem(IScreen item, bool close)
        {
            var afterClose = item as IAfterClose;
            base.DeactivateItem(item, close);
            if (afterClose != null && close)
                afterClose.AfterClose();
        }
