    var selectedObjects =
            (from System.Windows.Forms.DataGridViewRow r in dataGridView1.SelectedRows
            where r.DataBoundItem != null && r.DataBoundItem.GetType() == typeof(Effort.EffortCalculationRelation)
            select r.DataBoundItem).ToArray();
    if (dataGridView1.CurrentRow.IsNewRow && dataGridView1.SelectedRows.Count == 1)
    {
        // I tried accessing the parent object like this:
        //Effort.EffortCalculationRelation ecr = effort.CalculationRelations[effort.CalculationRelations.Count - 1];
        //propertyGrid1.SelectedObject = ecr;
        // Or accessing a binding source like:
        propertyGrid1.SelectedObject = calculationRelations.Current;
    }
    else
    {
        propertyGrid1.SelectedObjects = selectedObjects;
    }
