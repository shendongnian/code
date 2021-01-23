	class ModifiedRows
	{
		int m_position = 0;
		List<int> m_modifiedRowNumbersList;
		public ModifiedRows(List<int> modifiedRowNumbersList)
		{
			m_modifiedRowNumbersList = modifiedRowNumbersList;
		}
		public bool CanMoveToNextIndex { get { return m_position < m_modifiedRowNumbersList.Count; } }
		public bool CanMoveToPrevIndex { get { return m_position > 0; } }
		public void MoveToNextIndex()
		{
			if ( CanMoveToNextIndex )
			{
				m_position++;
			}
		}
		public void MoveToPrevIndex()
		{
			if ( CanMoveToPrevIndex )
			{
				m_position--;
			}
		}
		public int CurrentModifiedRowIndex
		{
			get
			{
				return m_modifiedRowNumbersList[m_position];
			}
		}
	}
