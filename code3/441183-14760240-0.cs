		/// <summary>
		/// The member variable m_fname is populated by input parameter
		/// and accepts either absolute or relative path.
		/// This method will determine if the supplied parameter was fully qualified, 
		/// and if not then qualify it.
		/// </summary>
		protected override void InternalProcessRecord()
		{
			base.InternalProcessRecord();
			
			string fname = null;
			if (Path.IsPathRooted(m_fname))
				fname = m_fname;
			else
				fname = Path.Combine(this.SessionState.Path.CurrentLocation.ToString(), m_fname);
			// If the file doesn't exist
			if (!File.Exists(fname))
				throw new FileNotFoundException("File does not exist.", fname);
		}
