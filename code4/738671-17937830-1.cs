    void OnTriggerEnter(Collider Portal)
    {
        PortalComponent p = Portal.gameObject.GetComponent<PortalComponent>();
         
         if (p != null) {
         Debug.Log ("teleporting");         
        
             gameObject.transform.position = p.Destination;    
          }
     }
