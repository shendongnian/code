    public bool IsResponseValid()
		{
			if(SNTPData.Length < SNTPDataLength || Mode != _Mode.Server)
			{
				return false;
			}
			else
			{
				return true;
			}
		}
