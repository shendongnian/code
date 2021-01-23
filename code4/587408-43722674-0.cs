	var t = new Table();
	var tableProps = new TableProperties();
	tableProps.TableJustification = new TableJustification { Val = TableRowAlignmentValues.Center };
	t.Append(tableProps);
	var row = new TableRow();
	var rowProps = new TableRowProperties();
	rowProps.Append(new TableJustification { Val = TableRowAlignmentValues.Center });
	row.Append(rowProps);
