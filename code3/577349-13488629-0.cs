    string sampleText = null;
    string Key = null;
    long KeyLength = 0;
    long Position = 0;
    int character = 0;
    
    for (Position = 1; Position <= sampleText.Length; Position++)
    {
    	character = Convert.ToInt32(Key[(Position % KeyLength) - KeyLength * ((Position % KeyLength) == 0) - 1]);
    	SimulateMidStatement.MidStatement(sampleText, Position, (char)(Convert.ToInt32(sampleText[Position - 1]) ^ character), 1);
    }
    
    //----------------------------------------------------------------------------------------
    //	Copyright © 2003 - 2012 Tangible Software Solutions Inc.
    //	This class can be used by anyone provided that the copyright notice remains intact.
    //
    //	This class simulates the behavior of the classic VB 'Mid' statement.
    //	(Note that this is unrelated to the VB 'Mid' function).
    //----------------------------------------------------------------------------------------
    public static class SimulateMidStatement
    {
    	public static void MidStatement(ref string target, int oneBasedStart, char insert)
    	{
    		if (target == null)
    			return;
    
    		target = target.Remove(oneBasedStart - 1, 1).Insert(oneBasedStart - 1, insert.ToString());
    	}
    	public static void MidStatement(ref string target, int oneBasedStart, string insert)
    	{
    		if (target == null || insert == null)
    			return;
    
    		target = target.PadRight(target.Length + insert.Length).Remove(oneBasedStart - 1, insert.Length).Insert(oneBasedStart - 1, insert).Substring(0, target.Length);
    	}
    	public static void MidStatement(ref string target, int oneBasedStart, string insert, int length)
    	{
    		if (target == null || insert == null)
    			return;
    
    		int minLength = System.Math.Min(insert.Length, length);
    		target = target.PadRight(target.Length + insert.Length).Remove(oneBasedStart - 1, minLength).Insert(oneBasedStart - 1, insert.Substring(0, minLength)).Substring(0, target.Length);
    	}
    }
