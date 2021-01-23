    public class controlBuilding : MonoBehaviour
    {
        ScaleModel cScale;
        public void Start()
        {
            cScale = GetComponent<ScaleModel>();
        }
        public void Update()
        {
            cScale.touchScaleB1();
        }
        public void OnGUI()
        {
        }
    }
