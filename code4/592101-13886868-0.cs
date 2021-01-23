    public int GenerateID(OtherThreadObj oto)
    {
		int result;
		this.Invoke((MethodInvoker)delegate { result = GenerateIDSafe(oto); });
		return result;
    }
