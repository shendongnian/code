    public class EnumTest : MonoBehaviour {
	public delegate void deTouchEvent (enTouchType t);
	public static event deTouchEvent  evTouchEvent;
	public enum enTouchType { SwipeLeft, SwipeRight }
	void Start () {
                // setup and do evt
		evTouchEvent += DummyTest.DummyDel;
		evTouchEvent(enTouchType.SwipeLeft);	
	}
    }
    public class DummyTest {
	public static void DummyDel(EnumTest.enTouchType t){
		if(t==EnumTest.enTouchType.SwipeLeft){
			Debug.Log("swipey_left");
		}
		else if(t==EnumTest.enTouchType.SwipeRight){
			Debug.Log("swipey_right");
		}
	}
    }
