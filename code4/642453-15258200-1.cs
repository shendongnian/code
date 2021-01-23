    public class CollisionRender : MonoBehaviour {
	//example collision types
	public enum CollisionTypes { Fatal,InSight };
	public CollisionTypes CollisionType = CollisionTypes.InSight;
	
	//turn renderer on.  
	void OnTriggerEnter(Collider other) {
		Visibility vis = other.gameObject.GetComponent<Visibility>();
		
		if(CollisionType == CollisionTypes.InSight){
			vis.SetVisible(true);
		}else if(CollisionType == CollisionTypes.Fatal){
			
			//if in 'fatal' zone, make visible and lock visibility.
			vis.SetVisible(true);
			vis.LockVisibility = true;
		}
    }
	void OnTriggerExit(Collider other) {
        Visibility vis = other.gameObject.GetComponent<Visibility>();
		vis.SetVisible(false);
    }
    }
