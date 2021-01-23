    //---------------------------------------------------------------------------
    bool TFmBatteryConfiguration::IsValidInt(char* x)
    {
    	bool Checked = true;
    
    	int i = 0;
    	do
    	{
    		//valid digit?
    		if (isdigit(x[i]))
    		{
    			//to the next character
    			i++;
    			Checked = true;
    		}
    		else
    		{
    			//to the next character
    			i++;
    			Checked = false;
    			break;
    		}
    	} while (x[i] != '\0');
    
    	return Checked;
    }
    
    //---------------------------------------------------------------------------
    bool TFmBatteryConfiguration::IsValidDouble(char* x)
    {
    	bool Checked = true;
    
    	int i = 0;
    
    	do
    	{
    		//valid digit?
    		if (isdigit(x[i]))
    		{
    			//to the next character 
    			i++;
    			Checked = true;
    		}
    		else if (x[i] == '.')
    		{
    			//First character
    			if (x[0] == '.')
    			{
    				Checked = false;
    				break;    
    			}
    			else if (x[i] == '.' && x[i+1] == '\0')
    			{
    				Checked = false;
    				break;
    			}
    			else
    			{
    				//to the next character
    				i++;
    			}
    		}
    		else
    		{
    			i++;
    			Checked = false;
    			break;
    		}
    	} while (x[i] != '\0');
    
    	return Checked;
    }
