    public class Visibility : MonoBehaviour {
        public bool LockVisibility = false;
	
        public void SetVisible(bool state){
            if(LockVisibility)return;
            renderer.enabled = state;
        }
    }
