    void Start () {
        StartCoroutine("SpawnObjects");
    }
    IEnumerator SpawnObjects()
    {
        GameObject SpawnLocation = (GameObject)Instantiate(myCube, spawnLocation, Quaternion.identity);
        float delay = Random.Range(1f, 5f); // adjust this to set frequency of obstacles
        yield return new WaitForSeconds(delay);
    }
