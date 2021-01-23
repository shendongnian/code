    using System.Web
    private void test() {
        if (HttpContext.Current != null) {
            // We are in a web environment
        }
        else {
            // We are not in a web environment
        }
    }
