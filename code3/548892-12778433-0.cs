	[TestMethod()]
	public void FormManagerTestSource()
	{
		this.dataGridView1 = new System.Windows.Forms.DataGridView();
		FormManager target = new FormManager(dataGridView1);
		Assert.AreEqual(0, dataGridView1.Rows.Count); // 0 initially.
		dataGridView1.BindingContext = new BindingContext(); // this makes it work.
		Assert.AreEqual(2, dataGridView1.Rows.Count); // 2 as expected.
	}
