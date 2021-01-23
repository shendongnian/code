	class OrderListEditor : UITypeEditor
	{
		public override System.Drawing.Design.UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
		{
			return System.Drawing.Design.UITypeEditorEditStyle.Modal;
		}
		public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
		{
			OrderList list = (OrderList)value;
			Console.WriteLine("There are " + list.Orders.Count + " orders");
			return list;
		}
	}
