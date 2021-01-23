    private void btnAdd_Click(object sender, EventArgs e) {
      this.UpdateParams("sampleApp");
      this.listBox1.Items.Add(this.GenerateURI());
      ResizeListBox();
    }
    private void btnUpdate_Click(object sender, EventArgs e) {
      this.UpdateParams("sampleApp");
      for (int index = 0; index < this.listBox1.Items.Count; index++) {
        this.listBox1.Items[index] = this.GenerateURI();
      }
      ResizeListBox();
    }
