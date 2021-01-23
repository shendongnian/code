    class LoadScene:MonoBehaviour{
     ***public static AssetBundle refrenceOfAsset;***
     private AssetBundle assetBundle;
    void Start(){
    ***DoNotDestroyOnLoad(gameObject);*** }
    protected IEnumerator LoadTheScene()
    {
        if (!Caching.IsVersionCached(url, version)){
            WWW www = WWW.LoadFromCacheOrDownload(url, version);
            yeild return www;  assetBundle = www.assetBundle;
            ***refrenceOfAsset = assetBundle;*** 
            www.Dispose();
            // Do what ever you want to do with the asset bundle but do not for get to unload it 
            refrenceOfAsset.Unload(true);
            }
        }
        else{
            Debug.Log("Asset Already Cached...");
            if(refrenceOfAsset!=null)
            refrenceOfAsset.Unload(true);
        }
    }
