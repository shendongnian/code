    public List<Vector3> GetCheckPoints()
    {
         GameObject[] objects = GameObject.FindGameObjectsWithTag("CheckPointTag");
         List<Vector3> objectPos = new List<Vector3>();
         foreach(GameObject object in objects)
              objectPos.Add(object.transform.Position;
    
         return objectPos;
    }
