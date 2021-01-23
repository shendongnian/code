	using UnityEngine;
	using System.Collections;
	using System.Collections.Generic;
	using System.IO;
	
	static public class MonoBehaviourUtility 
	{
		
		static public T GetManager<T>( ref T manager ) where T : MonoBehaviour
		{
			if (manager == null)
			{
				manager = (T)GameObject.FindObjectOfType( typeof( T ) );
				if (manager == null)
				{
					GameObject gameObject = new GameObject( typeof( T ).ToString() );
					manager = (T)gameObject.AddComponent( typeof( T ) );
	            }
	        }
	        return manager;
	    }
	
	}
