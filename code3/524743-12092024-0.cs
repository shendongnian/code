    if(dgvDetials.CurrentRow != null)
    {
        PartCode = dgvDetials.CurrentRow.Cells[0].Value.ToString(); 
        .....
        dgvDetials.CurrentRow.Cells[2].Value = 0; 
        dgvDetials.CurrentRow.Cells[5].Value = qtyInspCount; 
        dgvDetials.CurrentRow.Cells[3].Value = scrapCount; 
        dgvDetials.CurrentRow.Cells[4].Value = reworkCount; 
        .....
    }
