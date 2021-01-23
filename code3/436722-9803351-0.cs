    class Node{
      Vector[Link] connections;
      String name;
    }
    
    class Link{
      Node destination;
      int distance;
    }
    
    Vector[Vector[Node]] paths(Node source, Node end_dest, Vector[Vector[Node]] routes){
      for each route in routes{
        bool has_next = false;
        for each connection in source.connections{
          if !connection.destination in route {
            has_next = true;
            route.push(destination);
            if (!connection.destination == end_dest){
              paths(destination, end_dest, routes);
            }
          }
        }
        if !has_next {
          routes.remove(route) //watch out here, might mess up the iteration
        }
      }
      return routes;
    }
    
