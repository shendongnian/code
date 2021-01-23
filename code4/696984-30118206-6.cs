    bool IsTheSameCellValue(int column, int row)
    {
        DataGridViewCell cell1 = dataGridView1[column, row];
        DataGridViewCell cell2 = dataGridView1[column, row - 1];
        if (cell1.Value == null || cell2.Value == null)
        {
           return false;
        }
        return cell1.Value.ToString() == cell2.Value.ToString();
    }
