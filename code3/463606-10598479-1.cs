        public override object Serialize(IDesignerSerializationManager manager, object value)
        {
            BaseControl aCtl = value as BaseControl;
            if (aCtl == null)
                return null;
            if (aCtl.Labels == null)
                return null;
            int num = aCtl.Labels.Length;
            CodeStatementCollection stats = new CodeStatementCollection();
            stats.Add(new CodeSnippetExpression("CreateLabels(" + num.ToString() + ")"));
            return stats;
        }
