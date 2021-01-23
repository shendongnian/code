    public class IdCollection : List<ParticipantUsers>, IEnumerable<SqlDataRecord> {
    	#region IEnumerable<SqlDataRecord> Members
    
    	IEnumerator<SqlDataRecord> IEnumerable<SqlDataRecord>.GetEnumerator() {
    		SqlDataRecord rec = new SqlDataRecord(
    			new SqlMetaData("ProjectId", System.Data.SqlDbType.Int),
    			new SqlMetaData("ParticipantId", System.Data.SqlDbType.Int)
    		);
    
    		foreach (ParticipantUser ans in this) {
    			rec.SetInt32(0, ans.ProjectId);
    			rec.SetInt32(1, ans.ParticipantId);
    			yield return rec;
    		}
    	}
    
    	#endregion
    
    }
