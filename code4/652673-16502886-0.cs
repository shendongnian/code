    using UnityEngine;
    using System.Collections;
    using System.IO.Ports;
    
    public class checker : MonoBehaviour {
        
    	public static SerialPort sp = new SerialPort("COM9", 9600, Parity.None, 8, StopBits.One);
    	public string message, message1;
    	public int message2;
    	
    	
    	
    	void Start() {
    		
    		OpenConnection();   
    	
        
        }
    		
    	void Update() { 
    		
    		message2 = sp.ReadByte(); 
    	
    	} 
    
    	void OnGUI() 	{
    				
    		GUI.Label(new Rect(10, 180, 100, 220), "Sensor1: " + message2);
      
        }
    		
     	
    	public void OpenConnection() {
    		if (sp != null) 
    		{
    			if (sp.IsOpen) 
    			{
    				sp.Close();
    				message = "Closing port, because it was already open!";
    			}
    			else 
    			{
    				sp.Open(); 
    				sp.ReadTimeout = 1000;  
    				message = "Port Opened!";
    			}
    		}
    		else 
    		{
    			if (sp.IsOpen)
    			{
    				print("Port is already open");
    			}
    			else 
    			{
    				print("Port == null");
    			}
    		}
    	}
    	
    	
    
    	
    	void OnApplicationQuit() {
    		sp.Close();
    	}
    	
    	
    	
    }
