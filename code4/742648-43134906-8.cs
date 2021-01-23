    private void AddRow(string question, AnswerType answerType)
	{
		DataGridViewRow row = new DataGridViewRow();
		row.Cells.Add(this.CreateQuestionCell(question));
		row.Cells.Add(this.CreateAnswerCell(answerType));
		row.Cells[columnQuestion.Index].ReadOnly = true;
		this.dataGridView3.Rows.Add(row);
	}
