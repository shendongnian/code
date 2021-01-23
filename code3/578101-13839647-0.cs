    foreach (XmlNode unityObject in objects)
        {
			if(unityObject.Value!=lastUnityObject)
			{
				unityGameObjects.Add(GameObject.Find(unityObject.Value));
				
			}
			lastUnityObject = unityObject.Value;	
			
       }
