	using UnityEngine;
	using System.Collections;
	
	public class GetFloorName : MonoBehaviour 
	{
		public string NameOfRaycastHitObject;
	
		void Update () 
		{
			RaycastHit hitInfo;
			int layerMask = ~(1 << LayerMask.NameToLayer("Player"));
			float distance = 100f;
			
			if (Physics.Raycast(transform.position, Vector3.down, out hitInfo, distance, layerMask))
			{
				NameOfRaycastHitObject = hitInfo.collider.name;
			}
		}
	}
