    // Set up binding sources
    // fieldsDBDataSet1
    this.fieldsDBDataSet1.DataSetName = "FieldsDBDataSet1";
    this.fieldsDBDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
    // fieldsTableBindingSource - this is my data source for the ComboBox
    this.fieldsTableBindingSource.AllowNew = false;
    this.fieldsTableBindingSource.DataMember = "FieldsTable";
    this.fieldsTableBindingSource.DataSource = this.fieldsDBDataSet1;
    // Set up the ComboBoxes.  Here we make new bindings for the value:
    // public Binding(string propertyName, Object dataSource, string dataMember, boolean formattingEnabled);
    //   This constructs a binding that SETS propertyName to a value.
    //   The value comes from dataMember, a property or member of the object dataSource.
    // We also set the matching dataMember as our ValueMember, which must be different for all three boxes.
    // To set the dropdown source we use the DisplayMember, which should be the same for all three boxes.
    // fieldBox1
    this.fieldBox1.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.fieldsTableBindingSource, "ComboValue1", true));
    this.fieldBox1.ValueMember = "ComboValue1";
    this.fieldBox1.DataSource = this.fieldsTableBindingSource;
    this.fieldBox1.DisplayMember = "FieldName";
    this.fieldBox1.FormattingEnabled = true;
    this.fieldBox1.Location = new System.Drawing.Point(498, 89);
    this.fieldBox1.Name = "fieldBox1";
    this.fieldBox1.Size = new System.Drawing.Size(121, 21);
    this.fieldBox1.TabIndex = 5;
    this.fieldBox1.SelectedIndexChanged += new System.EventHandler(this.fieldBox1_SelectedIndexChanged);
    // fieldBox2
    this.fieldBox2.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.fieldsTableBindingSource, "ComboValue2", true));
    this.fieldBox2.ValueMember = "ComboValue2";
    this.fieldBox2.DataSource = this.fieldsTableBindingSource;
    this.fieldBox2.DisplayMember = "FieldName";
    this.fieldBox2.FormattingEnabled = true;
    this.fieldBox2.Location = new System.Drawing.Point(498, 116);
    this.fieldBox2.Name = "fieldBox2";
    this.fieldBox2.Size = new System.Drawing.Size(121, 21);
    this.fieldBox2.TabIndex = 6;
    // fieldBox3
    this.fieldBox3.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.fieldsTableBindingSource, "ComboValue3", true));
    this.fieldBox3.ValueMember = "ComboValue3";
    this.fieldBox3.DataSource = this.fieldsTableBindingSource;
    this.fieldBox3.DisplayMember = "FieldName";
    this.fieldBox3.FormattingEnabled = true;
    this.fieldBox3.Location = new System.Drawing.Point(498, 140);
    this.fieldBox3.Name = "fieldBox3";
    this.fieldBox3.Size = new System.Drawing.Size(121, 21);
    this.fieldBox3.TabIndex = 7;
