    private bool isOnMovingPlatform;
    private float offsetToKeepPlayerAbovePlatform = 2.2f;
    private float min = 0.2f;
    private float max = 1.2f;
    private void Update()
    {
	RaycastHit hit;
	if(Physics.Raycast (player.position, out hit))
	{
		if(hit.transform.name.Contains("MovingPlatform"))
		{
			Transform movingPlatform  = hit.collider.transform;
			
			if(movingPlatform.position.y - player.position.y <= min && movingPlatform.position.y - player.position.y >= max)
			{
				isOnMovingPlatform = true;
			}
			else
			{
				isOnMovingPlatform = false;
			}
		}
		
		if(isOnMovingPlatform)
		{
			player.position = new Vector3(hit.transform.x, hit.transform.y + offsetToKeepPlayerAbovePlatform, 0);
		}
	}
    }
